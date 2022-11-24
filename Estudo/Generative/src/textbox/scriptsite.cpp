// scriptsite.cpp

#include "stdafx.h"
#include "scriptsite.h"

HRESULT LoadTypeInfo(REFGUID guid, ITypeInfo** ppTypeInfo);

// IActiveScriptSite
STDMETHODIMP ScriptSite::GetDocVersionString(BSTR* pbstr)
{
    *pbstr = 0;
    return E_NOTIMPL;
}

STDMETHODIMP ScriptSite::GetLCID(LCID* plcid)
{
    *plcid = 0x409;
    return S_OK;
}

STDMETHODIMP ScriptSite::GetItemInfo(LPCOLESTR pstrName, DWORD dwReturnMask, IUnknown **ppunkItem, ITypeInfo **ppTypeInfo)
{
    if( !::_wcsicmp(pstrName, L"request") )
    {
        if( dwReturnMask & SCRIPTINFO_IUNKNOWN )
        {
            return m_request.QueryInterface(IID_IUnknown, (void**)ppunkItem);
        }

        if( dwReturnMask & SCRIPTINFO_ITYPEINFO	)
        {
            return LoadTypeInfo(CLSID_Request, ppTypeInfo);
        }

        return E_FAIL;
    }
    else if( !::_wcsicmp(pstrName, L"response") )
    {
        if( dwReturnMask & SCRIPTINFO_IUNKNOWN )
        {
            return m_response.QueryInterface(IID_IUnknown, (void**)ppunkItem);
        }

        if( dwReturnMask & SCRIPTINFO_ITYPEINFO	)
        {
            return LoadTypeInfo(CLSID_Response, ppTypeInfo);
        }

        return E_FAIL;
    }
    else
    {
        return TYPE_E_ELEMENTNOTFOUND;
    }
}

STDMETHODIMP ScriptSite::OnEnterScript()
{
    return S_OK;
}

STDMETHODIMP ScriptSite::OnLeaveScript()
{
    return S_OK;
}

STDMETHODIMP ScriptSite::OnScriptError(IActiveScriptError* pase)
{
    USES_CONVERSION;

    EXCEPINFO   ei;
    pase->GetExceptionInfo(&ei);

    CComBSTR    bstrError;
    if( FAILED(pase->GetSourceLineText(&bstrError)) )
    {
        bstrError = OLESTR("<no source line text>");
    }

    DWORD   dwSourceContext;
    ULONG   nLineNo;
    LONG    nCharPos;
    pase->GetSourcePosition(&dwSourceContext, &nLineNo, &nCharPos);

    char    sz[1048];
    wsprintf(sz, "Line: %u\nCharacter: %d\nSource: '%s'\n\n%s",
             nLineNo, nCharPos, LPCSTR(OLE2CT(bstrError)),
             OLE2CT(ei.bstrDescription ? ei.bstrDescription : OLESTR("<no description>")));
    
    HRESULT hr = S_OK;
    switch( ::MessageBox(0, sz, "Script Error", MB_ABORTRETRYIGNORE) )
    {
    case IDABORT:   hr = E_FAIL;    break;
    case IDRETRY:   hr = S_FALSE;   break;
    case IDIGNORE:  hr = S_OK;      break;
    }

    return hr;
}

STDMETHODIMP ScriptSite::OnScriptTerminate(const VARIANT* pvarResult, const EXCEPINFO* pei)
{
    return S_OK;
}

STDMETHODIMP ScriptSite::OnStateChange(SCRIPTSTATE ss)
{
    return S_OK;
}

// IActiveScriptSiteWindow
STDMETHODIMP ScriptSite::GetWindow(HWND* phwnd)
{
    *phwnd = GetDesktopWindow();
    return S_OK;
}

STDMETHODIMP ScriptSite::EnableModeless(BOOL bEnable)
{
    return S_OK;
}

static
HRESULT LoadTypeInfo(REFGUID guid, ITypeInfo** ppTypeInfo)
{
    *ppTypeInfo = 0;

    USES_CONVERSION;
    char    szFileName[MAX_PATH];
    ::GetModuleFileName(0, szFileName, sizeof(szFileName));

    HRESULT     hr;
    ITypeLib*   ptl;

    hr = ::LoadTypeLib(T2COLE(szFileName), &ptl);
    if( SUCCEEDED(hr) )
    {
        hr = ptl->GetTypeInfoOfGuid(guid, ppTypeInfo);
        ptl->Release();
    }

    return hr;
}

