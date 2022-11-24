// scriptsite.h

#pragma once
#include "textbox.h"

class Request : public IDispatchImpl<IRequest, &IID_IRequest>
{
public:
    void AddNameValue(const char* pszName, const char* pszValue)
    {
        m_mapNameValue[pszName] = pszValue;
    }

    // IUnknown
    STDMETHODIMP QueryInterface(REFIID riid, void** ppv)
    {
        if( riid == IID_IRequest || riid == IID_IDispatch || riid == IID_IUnknown )
        {
            *ppv = static_cast<IRequest*>(this);
        }
        else
        {
            *ppv = 0;
        }

        if( *ppv )
        {
            reinterpret_cast<IUnknown*>(*ppv)->AddRef();
            return S_OK;
        }

        return E_NOINTERFACE;
    }

    STDMETHODIMP_(ULONG) AddRef() { return 2; }
    STDMETHODIMP_(ULONG) Release() { return 1; }

    // IRequest
    STDMETHODIMP get_QueryString(BSTR bstrName, BSTR* pbstrValue)
    {
        USES_CONVERSION;
        CComBSTR    bstrValue = m_mapNameValue[OLE2A(bstrName)].c_str();
        *pbstrValue = bstrValue.Detach();
        return S_OK;
    }

private:
    map<string, string> m_mapNameValue;
};

class Response : public IDispatchImpl<IResponse, &IID_IResponse>
{
public:
    // IUnknown
    STDMETHODIMP QueryInterface(REFIID riid, void** ppv)
    {
        if( riid == IID_IResponse || riid == IID_IDispatch || riid == IID_IUnknown )
        {
            *ppv = static_cast<IResponse*>(this);
        }
        else
        {
            *ppv = 0;
        }

        if( *ppv )
        {
            reinterpret_cast<IUnknown*>(*ppv)->AddRef();
            return S_OK;
        }

        return E_NOINTERFACE;
    }

    STDMETHODIMP_(ULONG) AddRef() { return 2; }
    STDMETHODIMP_(ULONG) Release() { return 1; }

    // IResponse
    STDMETHODIMP Write(BSTR bstr)
    {
        wprintf(bstr);
        return S_OK;
    }
};

class ScriptSite :
    public IActiveScriptSite,
    public IActiveScriptSiteWindow
{
public:
    void AddNameValue(const char* pszName, const char* pszValue)
    {
        m_request.AddNameValue(pszName, pszValue);
    }

    // IUnknown
    STDMETHODIMP QueryInterface(REFIID riid, void** ppv)
    {
        if( riid == IID_IActiveScriptSite || riid == IID_IUnknown )
        {
            *ppv = static_cast<IActiveScriptSite*>(this);
        }
        else if( riid == IID_IActiveScriptSiteWindow )
        {
            *ppv = static_cast<IActiveScriptSiteWindow*>(this);
        }
        else
        {
            *ppv = 0;
        }

        if( *ppv )
        {
            reinterpret_cast<IUnknown*>(*ppv)->AddRef();
            return S_OK;
        }

        return E_NOINTERFACE;
    }

    STDMETHODIMP_(ULONG) AddRef() { return 2; }
    STDMETHODIMP_(ULONG) Release() { return 1; }

    // IActiveScriptSite
    STDMETHODIMP GetDocVersionString(BSTR* pbstr);
    STDMETHODIMP GetLCID(LCID* plcid);
    STDMETHODIMP GetItemInfo(LPCOLESTR pstrName, DWORD dwReturnMask, IUnknown **ppunkItem, ITypeInfo **ppTypeInfo);
    STDMETHODIMP OnEnterScript();
    STDMETHODIMP OnLeaveScript();
    STDMETHODIMP OnScriptError(IActiveScriptError* pase);
    STDMETHODIMP OnScriptTerminate(const VARIANT* pvarResult, const EXCEPINFO* pei);
    STDMETHODIMP OnStateChange(SCRIPTSTATE ss);

    // IActiveScriptSiteWindow
    STDMETHODIMP GetWindow(HWND* phwnd);
    STDMETHODIMP EnableModeless(BOOL bEnable);

private:
    ULONG       m_cRef;
    Request     m_request;
    Response    m_response;
};
