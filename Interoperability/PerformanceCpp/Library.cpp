#include "Library.h"

int Add(int a, int b) {
    return a + b;
}

int AddBatch(int baseValue, int times) {
    for (int i = 0; i < times; ++i) {
        baseValue = Add(baseValue, 1);
    }
    return baseValue;
}
