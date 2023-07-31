from traceback import format_exc, format_stack

mylist = [1, 2, 3, 4, 5]

try:
    print(mylist[99])
except Exception as e:
    print(f"{format_exc()}\nStack:")
    stack = format_stack()
    # -1 to exclude this expression from stack
    for x in range(len(stack)-1):
        stack_parts = stack[x].split('\n')
        origin = stack_parts[0]
        root = stack_parts[1]
        print(f"\t[{x}] ORIGIN:\t{origin}\n\t[{x}] ROOT:{root}\n")