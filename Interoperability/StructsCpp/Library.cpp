#include "Library.h"

#include <print>

Color Add(Color a, Color b) {
    uint8_t red = (a.r + b.r > 255) ? 255 : a.r + b.r;
    uint8_t green = (a.g + b.g > 255) ? 255 : a.g + b.g;
    uint8_t blue = (a.b + b.b > 255) ? 255 : a.b + b.b;
    uint8_t alpha = (a.a + b.a > 255) ? 255 : a.a + b.a;

    return {red, green, blue, alpha};
}

void Darken(Color *color) {
    if (color) {
        color->r = static_cast<uint8_t>(color->r * 0.8);
        color->g = static_cast<uint8_t>(color->g * 0.8);
        color->b = static_cast<uint8_t>(color->b * 0.8);
    }
}

void PrintHex(Color color) {
    std::println("0x{:08x}", color.rgba);
}
