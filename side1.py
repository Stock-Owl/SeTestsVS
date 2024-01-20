import asyncio
from math import sqrt

class Test:
    async def worker(n):
        for i in range(1, n+1):
            x = sqrt(i * n) * i - n
            await asyncio.sleep(0.001)

    async def boss(n, id):
        await Test.worker(n)
        print(f"id {id} done")

    async def main():
        stuff = []
        for i in range(5):
            stuff.append(Test.boss(100, i))
        await asyncio.gather(*stuff)

    def runner():
        asyncio.run(Test.main())

Test.runner()
