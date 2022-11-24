%{
/* textbox.lex */

#include <assert.h>
#include <stdlib.h>
#include "proctext.h"

BlockType   g_bt = btNone;
int         g_nLineNo = 1;

%}

%%
\<%@[ \t\n]*[Ll][Aa][Nn][Gg][Uu][Aa][Gg][Ee]=[ \t\n]*   {
                if( g_bt != btNone )
                {
                    ProcessError(g_nLineNo, g_bt, btLanguage);
                    fprintf(stderr, "@language can only be on the first line\n");
                    return -1;
                }

                if( g_nLineNo != 1 )
                {
                    ProcessError(g_nLineNo, g_bt, btLanguage);
                    return -1;
                }

                ProcessTransition(g_bt, btLanguage);
                g_bt = btLanguage;
            }

\<%=        {
                if( (g_bt != btText) && (g_bt != btNone) )
                {
                    ProcessError(g_nLineNo, g_bt, btPrint);
                    return -1;
                }
                ProcessTransition(g_bt, btPrint);
                g_bt = btPrint;
            }

\<%         {
                if( (g_bt != btText) && (g_bt != btNone) )
                {
                    ProcessError(g_nLineNo, g_bt, btScript);
                    return -1;
                }
                ProcessTransition(g_bt, btScript);
                g_bt = btScript;
            }

%\>\n?      {
                ProcessTransition(g_bt, btText);
                g_bt = btText;
                ++g_nLineNo;
            }

\n          {
                ++g_nLineNo;
                ProcessText(g_bt, yytext); /* handle nl */
            }

.           { ProcessText(g_bt, yytext); }
%%
