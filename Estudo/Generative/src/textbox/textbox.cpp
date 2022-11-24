// textbox.cpp : Defines the entry point for the console application.

#include "stdafx.h"
#include "proctext.h"
#include "scriptsite.h"
#include "textbox.h"
#include "textbox_i.c"

extern "C" int yylex();
extern "C" FILE* yyin;
extern "C" BlockType g_bt;

CComModule  _Module;
string      g_sScript;
string      g_sLanguage = "vbscript";

HRESULT TextBox(int argc, char* argv[]);
HRESULT ExecuteScript(IActiveScriptSite* pSite, const char* pszLanguage, const char* pszScript);

#define HR(_ex) { HRESULT _hr = _ex; if(FAILED(_hr)) return _hr; }
#define lengthof(_rg) (sizeof(_rg)/sizeof(*_rg))

int main(int argc, char* argv[])
{
    HRESULT hr = TextBox(argc, argv);
    if( FAILED(hr) )
    {
        fprintf(stderr, "hr= 0x%x\n", hr);
    }

    return hr;
}

HRESULT TextBox(int argc, char* argv[])
{
    ScriptSite  site;

    if( argc < 1 )
    {
        fprintf(stderr, "usage: textbox <file> [name=value]\n");
        return -1;
    }

    // Open template file
    const char* pszFile = argv[1];
    FILE*       pfile = fopen(pszFile, "rt");
    if( !pfile )
    {
        fprintf(stderr, "Couldn't open %s\n", pszFile);
        return 1;
    }

    yyin = pfile;

    // Get variables from the command line
    for( int i = 2; i < argc; ++i )
    {
        char*   pszPair = argv[i];
        size_t  len = strlen(pszPair);
        char*   pch = find(&pszPair[0], &pszPair[len], '=');
        if( pch != &pszPair[len] )
        {
            *pch++ = 0;
            site.AddNameValue(pszPair, pch);
        }
    }

    // Pre-process the script text
    yylex();
    ProcessTransition(g_bt, btNone);

    // Dump the pre-processed text
    /*
    printf("\n****************************pre-processed*********************************\n");
    printf(g_sScript.c_str());
    printf("\n****************************pre-processed*********************************\n");
    */

    // Register textbox typelib (TODO: Fix for Win9x)
    USES_CONVERSION;
    wchar_t szFileName[MAX_PATH];
    GetModuleFileNameW(0, szFileName, lengthof(szFileName));

    CComPtr<ITypeLib>   sptl;
    HR(LoadTypeLib(szFileName, &sptl));
    HR(RegisterTypeLib(sptl, szFileName, 0));

    // Init COM
    CoInitialize(0);

    // Init the module
    HR(_Module.Init(0, GetModuleHandle(0), &LIBID_TEXTBOXLib));

    // Execute the script
    HR(ExecuteScript(&site, g_sLanguage.c_str(), g_sScript.c_str()));

    // Terminate the module
    _Module.Term();
    CoUninitialize();
    return 0;
}

extern "C"
void ProcessTransition(BlockType btCurrent, BlockType btNew)
{
    switch( btCurrent )
    {
    // End of "something"
    case btText:
        if( stricmp(g_sLanguage.c_str(), "vbscript") == 0 )
        {
            g_sScript += "\"\n";
        }
        else
        {
            g_sScript += "\");\n";
        }
    break;

    // End of "<% something %>"
    case btScript:
        g_sScript += "\n";
    break;

    // End of "<%= something %>"
    case btPrint:
        if( stricmp(g_sLanguage.c_str(), "vbscript") == 0 )
        {
            g_sScript += "\n";
        }
        else
        {
            g_sScript += ");\n";
        }
    break;

    // End of "<%@ Language=something %>"
    case btLanguage:
        if( (stricmp(g_sLanguage.c_str(), "vbscript") != 0) &&
            (stricmp(g_sLanguage.c_str(), "jscript") != 0) )
        {
            extern int g_nLineNo;
            ProcessError(g_nLineNo, btCurrent, btNew);
            fprintf(stderr, "Only support 'vbscript' or 'jscript' language\n");
        }
    break;

    case btNone:
    break;

    default:
        assert(false);
    break;
    }

    switch( btNew )
    {
    // Start of "something"
    case btText:
        if( stricmp(g_sLanguage.c_str(), "vbscript") == 0 )
        {
            g_sScript += "Response.write \"";
        }
        else
        {
            g_sScript += "Response.write(\"";
        }
    break;

    // Start of "<% something %>"
    case btScript:
    break;

    // Start of "<%= something %>"
    case btPrint:
        if( stricmp(g_sLanguage.c_str(), "vbscript") == 0 )
        {
            g_sScript += "Response.write ";
        }
        else
        {
            g_sScript += "Response.write(";
        }
    break;

    // Start of "<%@ Language=something %>"
    case btLanguage:
        g_sLanguage.erase();
    break;

    case btNone:
    break;

    default:
        assert(false);
    break;
    }
}

extern "C"
void ProcessText(BlockType bt, const char* psz)
{
    // Handle one character at a time
    assert(psz[1] == 0);
    char    ch = *psz;

    switch( bt )
    {
    // Middle of "something"
    case btText:
        switch( ch )
        {
        case '"':
            if( stricmp(g_sLanguage.c_str(), "vbscript") == 0 )
            {
                g_sScript += "\"\"";
            }
            else
            {
                g_sScript += "\\\"";
            }
        break;

        case '\n':
            if( stricmp(g_sLanguage.c_str(), "vbscript") == 0 )
            {
                //g_sScript += "\" & chr(13) & chr(10)\n";
                g_sScript += "\" & chr(10)\n";
                g_sScript += "Response.write \"";
            }
            else
            {
                g_sScript += "\\n\");\n";
                g_sScript += "Response.write(\"";
            }
        break;

        case '\\':
            if( stricmp(g_sLanguage.c_str(), "vbscript") == 0 )
            {
                // vbs doesn't care
                g_sScript += ch;
            }
            else
            {
                // js does
                g_sScript += "\\\\";
            }
        break;

        default:
            g_sScript += ch;
        break;
        }
    break;

    // Middle of "<% something %>"
    case btScript:
        g_sScript += ch;
    break;

    // Middle of "<%= something %>"
    case btPrint:
        if( ch != '\n' ) g_sScript += ch;
    break;

    // Middle of "<%@ Language=something %>"
    case btLanguage:
        if( !isspace(ch) ) g_sLanguage += ch;
    break;

    default:
        assert(false);
    break;
    }
}

extern "C"
void ProcessError(int nLineNo, BlockType btCurrent, BlockType btNew)
{
    fprintf(stderr, "Syntax error, line %d\n", nLineNo);
}

HRESULT ExecuteScript(IActiveScriptSite* pSite, const char* pszLanguage, const char* pszScript)
{
    USES_CONVERSION;
    CComPtr<IActiveScript>  spScript;
    HR(spScript.CoCreateInstance(T2OLE(pszLanguage)));
    HR(spScript->SetScriptSite(pSite));

    CComQIPtr<IActiveScriptParse> spParse = spScript;
    if( !spParse ) HR(E_NOINTERFACE);

    HR(spParse->InitNew());
    HR(spParse->ParseScriptText(T2COLE(pszScript), 0, 0, 0, 0, 0, SCRIPTTEXT_ISVISIBLE, 0, 0));
    HR(spScript->AddNamedItem(L"Request", SCRIPTITEM_ISSOURCE | SCRIPTITEM_ISVISIBLE));
    HR(spScript->AddNamedItem(L"Response", SCRIPTITEM_ISSOURCE | SCRIPTITEM_ISVISIBLE));
    HR(spScript->SetScriptState(SCRIPTSTATE_CONNECTED));

    return S_OK;
}
