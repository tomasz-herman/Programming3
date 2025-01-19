cmake_minimum_required(VERSION 3.21)
project(HelloCpp)

set(CMAKE_CXX_STANDARD 23)

add_library(${PROJECT_NAME} SHARED Library.cpp)

set(TARGET_OUTPUT_DIRECTORY "${CMAKE_SOURCE_DIR}/../HelloCSharp")

add_custom_command(
    TARGET ${PROJECT_NAME} POST_BUILD
    COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_FILE:${PROJECT_NAME}> ${TARGET_OUTPUT_DIRECTORY}
    COMMENT "Copying library to ${TARGET_OUTPUT_DIRECTORY}"
)