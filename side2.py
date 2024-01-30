from multiprocessing import Process, freeze_support
from datetime import datetime as dt
from math import sqrt
from time import sleep

def benchmark(func):
    def wrapper(*args, **kwargs):
        start = dt.now()
        func(*args, **kwargs)
        end = dt.now()
        print("Final time:")
        print(end-start)
    return wrapper

def doshit():
    start = dt.now()
    x = 237
    for i in range(100000000):
        x = sqrt(sqrt(x ** 3))
    end = dt.now()
    print(end-start)

processes: list[Process] = []
processes.append(Process(target=doshit))
processes.append(Process(target=doshit))

if __name__ == '__main__':
    freeze_support()
    # for p in processes: 
    #     p.start()   

    processes[0].start()    
    processes[1].start()    

    sleep(60)