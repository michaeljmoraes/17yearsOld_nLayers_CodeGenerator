// proctext.h

#pragma once
#ifndef INC_PROCTEXT
#define INC_PROCTEXT

#ifdef __cplusplus
extern "C" {
#endif

typedef enum BlockType
{
    btText,
    btScript,
    btPrint,
    btLanguage,
    btNone,
} BlockType;

void ProcessTransition(BlockType btCurrent, BlockType btNew);
void ProcessText(BlockType bt, const char* psz);
void ProcessError(int nLineNo, BlockType btCurrent, BlockType btNew);

#ifdef __cplusplus
}
#endif

#endif  // INC_PROCTEXT
