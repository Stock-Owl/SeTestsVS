import asyncio
from random import randint

async def cofoo(iter: int, hostnum: int):
    for i in range(iter):
        x = randint(1, 5)
        await asyncio.sleep(x)
        if x == 1:
            print(f"True [{hostnum}]")
            return
        else:
            print(f"False [{hostnum}]")

async def host(id: int):
    await cofoo(5, id)
    print(f"Finished host {id}")

async def async_main():
    hosts = [host(1), host(2), host(3), host(4), host(5)]
    await asyncio.gather(*hosts)

def main():
    asyncio.run(async_main())

main()