#include "Library.h"

void Count(int from, int to, Callback callback) {
    for (int i = from; i < to; ++i) {
        callback(i);
    }
}
