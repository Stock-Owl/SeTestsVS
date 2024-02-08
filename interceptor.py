from regex import findall
import base64

class Interceptor:
    def __init__(self, intercepts: list[dict[str, dict[str, str]]] = None):
        self.to_intercept: list[dict[str, dict[str, str]]] = []
        if intercepts is not None:
            self.to_intercept = intercepts

    def Intercept(self, request) -> None:
        for intercept_dict in self.to_intercept:
            for intercept in intercept_dict.values():
                type_ = intercept["type"].lower()
                key_: str = intercept["key"]
                value_: str = intercept["value"]
                to_encode: list[str] = findall("encode\([^\(]*\)", value_)

                for item in to_encode:
                    item_content: str = item.removeprefix("encode(").removesuffix(")")
                    value_ = value_.replace(item, Interceptor.Encode(item_content))
                print(f"{key_} {value_}")   
                match type_:
                    case "header":
                        request.headers[key_] = value_
                    # YAGNI
                    case _:
                        print(f"Unkwnown intercept type {type_} If you need this type to be implemented, hit the Issues page!")
    
    def Add(self, name: str, type_: str, key: str, value: str) -> None:
        to_add: dict[str, dict[str, str]] = \
        {
            name: {
                "type": type_,
                "key": key,
                "value": value
            }
        }
        self.to_intercept.append(to_add)

    def Remove(self, name: str) -> None:
        for intercept in self.to_intercept:
            if name in intercept.keys():
                self.to_intercept.remove(intercept)

    def Encode(string: str) -> str:
        return base64.encodebytes(string.encode()).decode().strip()
