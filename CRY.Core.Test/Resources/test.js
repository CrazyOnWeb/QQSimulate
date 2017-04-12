var TetsMethod = function () {
    var calu = 10;
    _method1 = function () {
        return "this is a string";
    }
    _method2 = function (a, b) {
        return a - b;
    }
    _method3 = function () {
        return {
            name: "name",
            age: 24
        };
    }
    return {
        method1: _method1,
        method2: _method2,
        method3: _method3
    }
}()