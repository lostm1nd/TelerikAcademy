class Person
	constructor: (name, age) ->
		this.name = name
		this.age = age
	sayHello: () ->
		alert('Hello, stranger. I am ' + this.name)
	grow: () ->
		this.age +=1

class Robot extends Person
	constructor: (name, age) ->
		Person.call(this, name, age)
	sayHello: () ->
		alert('I am human also! My name is ' + this.name)

pers = new Person('John', 29)
rbt = new Robot('Jenkins', 101)

nav = document.getElementsByTagName('nav')[0]
nav.addEventListener('click', () ->
	alert(pers.sayHello()))

main = document.getElementById('main')
main.addEventListener('click', () ->
	alert(rbt.sayHello()))
