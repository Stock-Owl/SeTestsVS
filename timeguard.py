import datetime as dt

class TimeGuard:
    def __init__(self, target_ms: str):
        # I could write a format parser here or do some magic with class builtins
        # But I will just YAGNI it
        self.target_t: dt.timedelta = dt.timedelta(milliseconds=int(target_ms))
        self.start: dt.datetime | None = None
        self.end: dt.datetime | None = None

    def __str__(self):
        param_: str
        try:
            param_ = "start"
            assert self.start is not None
            param_ = "end"
            assert self.end is not None
        except:
            raise UnboundLocalError(f"TimeGuard {self.name} {param_} property is unbound")
        delta: dt.timedelta = self.end - self.start
        if delta <= self.target_ms:
            return f"✅ TimeGuard {self.name} is inside of given timerange {self.target_t} ms"
        return f"❌ TimeGuard {self.name} is outside of given timerange {self.target_t} ms"
            
    def start(self):
        self.start = dt.datetime.now()

    def end(self):
        self.end = dt.datetime.now()