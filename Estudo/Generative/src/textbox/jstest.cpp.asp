<%@ language=jscript %>
<% // test.cpp.asp %>
<%
    var greeting = Request.QueryString("greeting");
    if( greeting.length == 0 ) greeting = "Hello, World.";
%>
// test.cpp

<% if( Request.QueryString("iostream").length != 0 ) { %>
#include <iostream>
using namespace std;
<% } else { %>
#include <stdio.h>
<% } %>

int main()
{
<% if( Request.QueryString("iostream").length != 0 ) { %>
    cout << "<%= greeting %>" << endl;
<% } else { %>
    printf("<%= greeting %>\n");
<% } %>
    return 0;
}
