<%@ language=vbscript %>
<% ' test.cpp.asp %>
<%
    greeting = request.QueryString("greeting")
    if len(greeting) = 0 then greeting = "Hello, World."
%>
// test.cpp

<% if request.QueryString("iostream") <> "" then %>
#include <iostream>
using namespace std;
<% else %>
#include <stdio.h>
<% end if %>

int main()
{
<% if request.QueryString("iostream") <> "" then %>
    cout << "<%= greeting %>" << endl;
<% else %>
    printf("<%= greeting %>\n");
<% end if %>
    return 0;
}
