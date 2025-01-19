#pragma once

#if defined(_WIN32) || defined(_WIN64)
#define EXPORT __declspec(dllexport)
#else
#define EXPORT __attribute__((visibility("default")))
#endif

extern "C" EXPORT const char* CreateString();
extern "C" EXPORT void PrintString(const char* str);
extern "C" EXPORT void DestroyString(const char* str);
