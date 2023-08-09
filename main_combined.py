from core_combined import Core

choose = input("Firefox or Chrome? ").lower()
if choose == "firefox":
    Run = Core.Firefox.RunDriver
elif choose == "chrome":
    Run = Core.Chrome.RunDriver
else: 
    print("Huh?")
json = './unit_run.json'
Run(json)
input()