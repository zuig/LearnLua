Window = {} --创建一个名字空间

--使用默认值来创建一个原型
Window.prototype = { x =0 , y = 0 , with = 100 , height = 100}
Window.mt = {} --创建元表
--声明构造函数
function Window.new( o )
	setmetatable(o,Window.mt)
	return o
end

--[[
--定义__index元方法一
Window.mt.__index = function ( table , key )
	return Window.prototype[key]
end
--]]

--定义__index元方法二
Window.mt.__index = Window.prototype

w = Window.new{x=10,y=20}
print(w.with)