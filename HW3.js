//  Task 1

class Product {
  constructor(name, quantity, isBought) {
    this.name = name;
    this.quantity = quantity;
    this.isBought = isBought;
  }
}

function getList(products) {
  for (let product of products.sort(
    (a, b) => Number(a.isBought) - Number(b.isBought)
  )) {
    if (product.isBought) {
      console.log(`${product.name} ${product.quantity} - bought`);
    } else {
      console.log(`${product.name} ${product.quantity} - not bought`);
    }
  }
}

function addProduct(product, products) {
  for (let prod of products) {
    if (prod.name === product.name) {
      prod.quantity += product.quantity;
      prod.isBought = false;
      return;
    }
  }

  products.push(product);
}

function buyProduct(productName, products) {
  for (let product of products) {
    if (product.name === productName) {
      product.isBought = true;
      return;
    }
  }
}

let productList = [
  new Product("apple", 5, false),
  new Product("pear", 7, true),
  new Product("tangerine", 6, false),
  new Product("banana", 6, true),
];

addProduct(new Product("apple", 5, false), productList);
addProduct(new Product("tomato", 5, false), productList);
buyProduct("tangerine", productList);
getList(productList);

/////////////////////////////////////////////////////

//  Task 2

class Item {
  constructor(name, quantity, price) {
    this.name = name;
    this.quantity = quantity;
    this.price = price;
  }
}

function getReceipt(receipt) {
  for (let item of receipt) {
    console.log(`${item.name} ${item.quantity} ${item.price}$`);
  }
}

function totalPrice(receipt) {
  let price = 0;
  for (item of receipt) {
    price += item.price;
  }

  return price;
}

function mostExpensive(receipt) {
  return receipt.sort((a, b) => b.price - a.price)[0];
}

function averagePrice(receipt) {
  return totalPrice(receipt) / receipt.length;
}

let Receipt = [new Item("tshirt", 5, 30), new Item("dress", 5, 50)];

console.log("Receipt: ");
getReceipt(Receipt);
console.log(`Total price: ${totalPrice(Receipt)}$`);
console.log(`The most expensive item: ${mostExpensive(Receipt).name}`);
console.log(`Average price: ${averagePrice(Receipt)}$`);

/////////////////////////////////////////////////////

//  Task 3

class Style {
  constructor(name, value) {
    this.name = name;
    this.value = value;
  }
}

function getStyles(styles, text) {
  let p = '<p style="';

  styles.forEach((style) => {
    p += `${style.name}: ${style.value};`;
  });

  p += `">${text}</p>`;

  document.write(p);
}

let styles = [new Style("background", "yellow"), new Style("color", "blue")];

getStyles(styles, "Hello");

/////////////////////////////////////////////////////

//  Task 4

class Auditorium {
  constructor(name, places, faculty) {
    this.name = name;
    this.places = places;
    this.faculty = faculty;
  }
}

class Group {
  constructor(name, students, faculty) {
    this.name = name;
    this.students = students;
    this.faculty = faculty;
  }
}

function getAuditoriums(auditoriums) {
  for (auditorium of auditoriums) {
    console.log(
      `${auditorium.name} ${auditorium.places} ${auditorium.faculty}`
    );
  }
}

function getAuditoriumsByFaculty(faculty, auditoriums) {
  for (auditorium of auditoriums) {
    if (auditorium.faculty == faculty) {
      console.log(
        `${auditorium.name} ${auditorium.places} ${auditorium.faculty}`
      );
    }
  }
}

function getAuditoriumsForGroup(group, auditoriums) {
  for (auditorium of auditoriums) {
    if (
      auditorium.faculty == group.faculty &&
      auditorium.places >= group.students
    ) {
      console.log(
        `${auditorium.name} ${auditorium.places} ${auditorium.faculty}`
      );
    }
  }
}

function sortByPlaces(auditoriums) {
  return auditoriums.sort((a, b) => b.places - a.places);
}

function sortByName(auditoriums) {
  return auditoriums.sort((a, b) => a.name.localeCompare(b.name));
}

let auditoriums = [
  new Auditorium("105", "20", "IT"),
  new Auditorium("506", "15", "IT"),
  new Auditorium("304", "18", "KTF"),
];

let group1 = new Group("602", 18, "IT");

console.log("All auditoriums:");
getAuditoriums(auditoriums);
console.log("Auditoriums for IT:");
getAuditoriumsByFaculty("IT", auditoriums);
console.log("Auditoriums for group1:");
getAuditoriumsForGroup(group1, auditoriums);
console.log("All auditoriums sorted by places:");
getAuditoriums(sortByPlaces(auditoriums));
console.log("All auditoriums sorted by name:");
getAuditoriums(sortByName(auditoriums));
