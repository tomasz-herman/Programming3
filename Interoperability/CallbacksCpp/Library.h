#pragma once

#if defined(_WIN32) || defined(_WIN64)
#define EXPORT __declspec(dllexport)
#else
#define EXPORT __attribute__((visibility("default")))
#endif

typedef void (__cdecl *Callback)(int value);

extern "C" void Count(int from, int to, Callback callback);