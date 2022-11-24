// Usage: handlers.js typeLibName ifaceName className

var undefined;
function echo(s) { WScript.Echo(s); }
function exit(s) { echo(s); WScript.quit(); }

Number.prototype.toHex = function(pad)
{
  if( pad == undefined ) pad = 0;
  var n = (this < 0 ? this + 0x100000000 : this);
  var s = n.toString(16);
  return "00000000".substr(0, pad-s.length) + s;
}

function hex(n, pad)
{
  return n.toHex(pad);
}

var VT_EMPTY = 0;
var VT_NULL = 1;
var VT_I2 = 2;
var VT_I4 = 3;
var VT_R4 = 4;
var VT_R8 = 5;
var VT_CY = 6;
var VT_DATE = 7;
var VT_BSTR = 8;
var VT_DISPATCH = 9;
var VT_ERROR = 10;
var VT_BOOL = 11;
var VT_VARIANT = 12;
var VT_UNKNOWN = 13;
var VT_DECIMAL = 14;
var VT_I1 = 16;
var VT_UI1 = 17;
var VT_UI2 = 18;
var VT_UI4 = 19;
var VT_I8 = 20;
var VT_UI8 = 21;
var VT_INT = 22;
var VT_UINT = 23;
var VT_VOID = 24;
var VT_HRESULT  = 25;
var VT_PTR = 26;
var VT_SAFEARRAY = 27;
var VT_CARRAY = 28;
var VT_USERDEFINED = 29;
var VT_LPSTR = 30;
var VT_LPWSTR = 31;
var VT_FILETIME = 64;
var VT_BLOB = 65;
var VT_STREAM = 66;
var VT_STORAGE = 67;
var VT_STREAMED_OBJECT = 68;
var VT_STORED_OBJECT = 69;
var VT_BLOB_OBJECT = 70;
var VT_CF = 71;
var VT_CLSID = 72;
var VT_VECTOR = 0x1000;
var VT_ARRAY = 0x2000;
var VT_BYREF = 0x4000;
var VT_RESERVED = 0x8000;
var VT_ILLEGAL = 0xffff;
var VT_ILLEGALMASKED = 0xfff;
var VT_TYPEMASK = 0xfff;

function cppType(vt) {
  switch(vt) {
  case VT_I2:  return "short";
  case VT_I4:  return "long";
  case VT_R4:  return "float";
  case VT_R8:  return "double";
  case VT_CY:  return "CY";
  case VT_DATE:  return "DATE";
  case VT_BSTR:  return "BSTR";
  case VT_DISPATCH:  return "IDispatch*";
  case VT_ERROR:  return "SCODE";
  case VT_BOOL:  return "VARIANT_BOOL";
  case VT_VARIANT:  return "VARIANT";
  case VT_UNKNOWN:  return "IUnknown*";
  case VT_UI1:  return "BYTE";
  case VT_DECIMAL:  return "DECIMAL";
  case VT_I1:  return "char";
  case VT_UI2:  return "USHORT";
  case VT_UI4:  return "ULONG";
  case VT_I8:  return "__int64";
  case VT_UI8:  return "unsigned __int64";
  case VT_INT:  return "int";
  case VT_UINT:  return "UINT";
  case VT_HRESULT:  return "HRESULT";
  case VT_VOID:  return "void";
  case VT_LPSTR:  return "char*";
  case VT_LPWSTR:  return "wchar_t*";
  default: return "ERROR!";
  }
}

if( WScript.arguments.length != 3 ) {
  exit("Usage: handlers.js typeLibName ifaceName className");
}

function cppArgs(params) {
  var args = "";

  for( var i = 1; i != params.count + 1; ++i ) {
    var param = params(i);
    var ti = param.varTypeInfo;
    args += cppType(ti.varType);
    if( ti.pointerLevel != 0 ) args += "*";
    args += " " + param.name;
    if( i != params.count ) args += ", ";
  }
  
  return args;
}

// cppType() maps a COM type to a C++ type
// cppArgs() returns a comma-delimited list of function args

var typeLibName = WScript.arguments(0);
var ifaceName = WScript.arguments(1);
var className = WScript.arguments(2);
var sinkID = 1; // For simplicity
var major = 1;
var minor = 0;
var iid = "DIID_" + ifaceName;

var tliApp = new ActiveXObject("tli.tliApplication");
var tliInfo = tliApp.typeLibInfoFromFile(typeLibName);
var iface = tliInfo.interfaces.namedItem(ifaceName);
var members = iface.members;

echo("class " + className + " :");
echo("  public IDispEventImpl<" + sinkID + ", " + className + ", ");
echo("                        &" + iid + ", " +
     major + ", " + minor + ">");
echo("{");
echo("public:");
echo("BEGIN_SINK_MAP(" + className + ")");
for( var i = 1; i != members.count + 1; ++i ) {
  var member = members.item(i);
  echo("  SINK_ENTRY_EX(" + sinkID + ", " + iid + ", 0x" +
       hex(member.memberID, 8) + ", " + member.name + ")");
}
echo("END_SINK_MAP()");

echo("");
echo("private:");
for( var i = 1; i != members.count + 1; ++i ) {
  var member = members.item(i);
  echo("  " + cppType(member.returnType.varType) +
       " __stdcall " + member.name + "(" +
       cppArgs(member.parameters) + ");");
}
echo("};");
