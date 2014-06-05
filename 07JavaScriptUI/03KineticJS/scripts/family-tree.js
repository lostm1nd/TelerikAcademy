(function drawFamilyTree() {



function createNodeList(input) {
  var nodeList = {};

  input.forEach(function(obj) {
    var mom = nodeList[obj.mother] || new Node(obj.mother);
    var dad = nodeList[obj.father] || new Node(obj.father);
    mom.partner = dad;
    dad.partner = mom;

    obj.children.forEach(function(child) {
      var kid = nodeList[child] || new Node(child);
      kid.hasParent = true;
      mom.children.push(kid);
      dad.children.push(kid);
      nodeList[kid.name] = kid;
    });

    nodeList[mom.name] = mom;
    nodeList[dad.name] = dad;
  });

  return nodeList;
}

function Node(name, hasParent, children) {
  this.name = name;
  this.hasParent = hasParent || false;
  this.children = children || [];
  this.partner = undefined;
}

function findRoot(nodes) {
  var root;

  for (var node in nodes) {
    if (!nodes[node].hasParent && !nodes[node].partner.hasParent) {
      root = nodes[node];
    }
  }

  return root;
}

function breathFirstSearch(root) {
  var queue = [];

  queue.push(root);

  while (queue.length > 0) {
    var next = queue.shift();

    console.log(next.name);

    var children = next.children;
    for (var child in children) {
      queue.push(children[child]);
    }
  }
}

var familyMembers = [{
  mother: 'Maria Petrova',
  father: 'Georgi Petrov',
  children: ['Teodora Petrova', 'Peter Petrov']
}, {
  mother: 'Petra Stamatova',
  father: 'Todor Stamatov',
  children: ['Maria Petrova']
}];

var people = createNodeList(familyMembers);
var root = findRoot(people);
breathFirstSearch(root);

// console.log(root);

}());
