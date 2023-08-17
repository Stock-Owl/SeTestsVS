from core import Core
from json import loads
from multiprocessing import freeze_support

def main():
    Run = Core.RunDrivers
    path = './run.json'
    with open(path, mode='r', encoding='utf-8') as f:
        json = loads(f.read())
    Run(json)

if __name__ == '__main__':
    freeze_support()
    main()
