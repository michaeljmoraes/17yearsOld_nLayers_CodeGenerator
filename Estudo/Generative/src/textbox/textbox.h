
#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0347 */
/* at Mon Sep 17 16:18:10 2001
 */
/* Compiler settings for textbox.idl:
    Os, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 440
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __textbox_h__
#define __textbox_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IRequest_FWD_DEFINED__
#define __IRequest_FWD_DEFINED__
typedef interface IRequest IRequest;
#endif 	/* __IRequest_FWD_DEFINED__ */


#ifndef __IResponse_FWD_DEFINED__
#define __IResponse_FWD_DEFINED__
typedef interface IResponse IResponse;
#endif 	/* __IResponse_FWD_DEFINED__ */


#ifndef __Request_FWD_DEFINED__
#define __Request_FWD_DEFINED__

#ifdef __cplusplus
typedef class Request Request;
#else
typedef struct Request Request;
#endif /* __cplusplus */

#endif 	/* __Request_FWD_DEFINED__ */


#ifndef __Response_FWD_DEFINED__
#define __Response_FWD_DEFINED__

#ifdef __cplusplus
typedef class Response Response;
#else
typedef struct Response Response;
#endif /* __cplusplus */

#endif 	/* __Response_FWD_DEFINED__ */


/* header files for imported files */
#include "unknwn.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

#ifndef __IRequest_INTERFACE_DEFINED__
#define __IRequest_INTERFACE_DEFINED__

/* interface IRequest */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IRequest;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("0722AE71-6F84-11D2-9870-00600823CFFB")
    IRequest : public IDispatch
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_QueryString( 
            /* [in] */ BSTR bstrName,
            /* [retval][out] */ BSTR *pbstrValue) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IRequestVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IRequest * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IRequest * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IRequest * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IRequest * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IRequest * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IRequest * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IRequest * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_QueryString )( 
            IRequest * This,
            /* [in] */ BSTR bstrName,
            /* [retval][out] */ BSTR *pbstrValue);
        
        END_INTERFACE
    } IRequestVtbl;

    interface IRequest
    {
        CONST_VTBL struct IRequestVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IRequest_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IRequest_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IRequest_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IRequest_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IRequest_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IRequest_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IRequest_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IRequest_get_QueryString(This,bstrName,pbstrValue)	\
    (This)->lpVtbl -> get_QueryString(This,bstrName,pbstrValue)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [propget] */ HRESULT STDMETHODCALLTYPE IRequest_get_QueryString_Proxy( 
    IRequest * This,
    /* [in] */ BSTR bstrName,
    /* [retval][out] */ BSTR *pbstrValue);


void __RPC_STUB IRequest_get_QueryString_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IRequest_INTERFACE_DEFINED__ */


#ifndef __IResponse_INTERFACE_DEFINED__
#define __IResponse_INTERFACE_DEFINED__

/* interface IResponse */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IResponse;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("0722AE72-6F84-11D2-9870-00600823CFFB")
    IResponse : public IDispatch
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Write( 
            /* [in] */ BSTR bstr) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IResponseVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IResponse * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IResponse * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IResponse * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IResponse * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IResponse * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IResponse * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IResponse * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        HRESULT ( STDMETHODCALLTYPE *Write )( 
            IResponse * This,
            /* [in] */ BSTR bstr);
        
        END_INTERFACE
    } IResponseVtbl;

    interface IResponse
    {
        CONST_VTBL struct IResponseVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IResponse_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IResponse_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IResponse_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IResponse_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IResponse_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IResponse_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IResponse_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IResponse_Write(This,bstr)	\
    (This)->lpVtbl -> Write(This,bstr)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE IResponse_Write_Proxy( 
    IResponse * This,
    /* [in] */ BSTR bstr);


void __RPC_STUB IResponse_Write_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IResponse_INTERFACE_DEFINED__ */



#ifndef __TEXTBOXLib_LIBRARY_DEFINED__
#define __TEXTBOXLib_LIBRARY_DEFINED__

/* library TEXTBOXLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_TEXTBOXLib;

EXTERN_C const CLSID CLSID_Request;

#ifdef __cplusplus

class DECLSPEC_UUID("0722AE74-6F84-11D2-9870-00600823CFFB")
Request;
#endif

EXTERN_C const CLSID CLSID_Response;

#ifdef __cplusplus

class DECLSPEC_UUID("0722AE75-6F84-11D2-9870-00600823CFFB")
Response;
#endif
#endif /* __TEXTBOXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  BSTR_UserSize(     unsigned long *, unsigned long            , BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal(  unsigned long *, unsigned char *, BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal(unsigned long *, unsigned char *, BSTR * ); 
void                      __RPC_USER  BSTR_UserFree(     unsigned long *, BSTR * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


