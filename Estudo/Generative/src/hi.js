function echo(s) { WScript.Echo(s); }

echo("content-type: text/html");
echo("");
for( var i = 3; i != 8; ++i ) {
  echo("<font size=" + i + ">Hi</font><br>");
}
