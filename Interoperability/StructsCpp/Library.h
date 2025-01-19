#pragma once

#include <cstdint>

#if defined(_WIN32) || defined(_WIN64)
#define EXPORT __declspec(dllexport)
#else
#define EXPORT __attribute__((visibility("default")))
#endif

struct Color
{
    union
    {
        struct
        {
            uint8_t r;
            uint8_t g;
            uint8_t b;
            uint8_t a;
        };

        uint32_t rgba;
    };
};

extern "C" EXPORT Color Add(Color a, Color b);
extern "C" EXPORT void Darken(Color *color);
extern "C" EXPORT void PrintHex(Color color);
