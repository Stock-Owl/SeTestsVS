import asyncio
import random
from math import sqrt

async def worker(n):
    for i in range(1, n+1):
        x = sqrt(i * n) * i - n
        await asyncio.sleep(0.001)

async def boss(n, id):
    await worker(n)
    print(f"id {id} done")

async def main():
    stuff = []
    for i in range(5):
        stuff.append(boss(1000, i))
    await asyncio.gather(*stuff)

asyncio.run(main())
print("---")
asyncio.run(main())
print("---")
asyncio.run(main())
print("---")
asyncio.run(main())
print("---")
asyncio.run(main())
