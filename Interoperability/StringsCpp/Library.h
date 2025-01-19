#pragma once

#if defined(_WIN32) || defined(_WIN64)
#define EXPORT __declspec(dllexport)
#else
#define EXPORT __attribute__((visibility("default")))
#endif

extern "C" EXPORT void PrintAnsiString(const char* str);
extern "C" EXPORT void PrintUnicodeString(const char16_t* str);
extern "C" EXPORT const char* GetAnsiString();
extern "C" EXPORT const char16_t* GetUnicodeString();
extern "C" EXPORT void Encode(char* text);
