#include "Library.h"

#include <print>
#include <codecvt>

void PrintAnsiString(const char *str)
{
    std::println("String: '{}'\n", str);
}

void PrintUnicodeString(const char16_t *str)
{
    std::u16string u16string(str);

    std::wstring_convert<std::codecvt_utf8_utf16<char16_t>, char16_t> converter;
    std::string utf8String = converter.to_bytes(u16string);

    std::println("UTF-16 String: '{}'\n", utf8String);
}

const char *GetAnsiString()
{
    static const char *ansiString = "String from C++";
    return ansiString;
}

const char16_t *GetUnicodeString()
{
    static const char16_t *unicodeString = u"UTF-16 string from C++ \U0001F44B";
    return unicodeString;
}

void Encode(char *text)
{
    if (text == nullptr) return;

    while (*text)
    {
        char c = *text;

        if (c >= 'A' && c <= 'Z')
        {
            *text = static_cast<char>(((c - 'A' + 13) % 26) + 'A');
        }
        else if (c >= 'a' && c <= 'z')
        {
            *text = static_cast<char>(((c - 'a' + 13) % 26) + 'a');
        }

        text++;
    }
}
