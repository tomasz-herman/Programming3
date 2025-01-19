#pragma once

#if defined(_WIN32) || defined(_WIN64)
#define EXPORT __declspec(dllexport)
#else
#define EXPORT __attribute__((visibility("default")))
#endif

extern "C" EXPORT int Add(int a, int b);
extern "C" EXPORT int AddBatch(int baseValue, int times);