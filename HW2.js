// Task 1
var car = {
  manufacturer: "Toyota",
  model: "Camry",
  year: "2020",
  avgSpeed: "100",
  getInfo: function () {
    console.log(
      `manufacturer: ${this.manufacturer}\nmodel: ${this.model}\nyear: ${this.year}\naverage speed: ${this.avgSpeed}`
    );
  },
  getTime: function (distance) {
    let time = distance / this.avgSpeed;
    time += Math.floor(time / 4);
    return time;
  },
};

car.getInfo();
console.log(`time spent to reach 900km: ${car.getTime(900)} hours`);

///////////////////

// Task 2

var fraction = {
  numerator: 27,
  denominator: 12,
  show: function () {
    console.log(`${this.numerator} / ${this.denominator}`);
  },
  sum: function (fraction2) {
    if (this.denominator === fraction2.denominator) {
      this.numerator += fraction2.numerator;
    } else {
      this.numerator =
        this.numerator * fraction2.denominator +
        fraction2.numerator * this.denominator;
      this.denominator *= fraction2.denominator;
    }

    this.reduction();
  },
  difference: function (fraction2) {
    if (this.denominator === fraction2.denominator) {
      this.numerator -= fraction2.numerator;
    } else {
      this.numerator =
        this.numerator * fraction2.denominator -
        fraction2.numerator * this.denominator;
      this.denominator *= fraction2.denominator;
    }

    this.reduction();
  },
  product: function (fraction2) {
    this.denominator *= fraction2.denominator;
    this.numerator *= fraction2.numerator;

    this.reduction();
  },
  quotient: function (fraction2) {
    this.denominator *= fraction2.numerator;
    this.numerator *= fraction2.denominator;

    this.reduction();
  },
  reduction: function () {
    function getDividers(num) {
      let dividers = new Array();
      for (let i = 1; i <= num; i++) {
        if (num % i == 0) {
          dividers.push(i);
        }
      }

      return dividers;
    }

    let denomDividers = getDividers(this.denominator);
    let numDividers = getDividers(this.numerator);
    let gcd = 1;

    denomDividers = denomDividers.reverse();

    denomDividers.forEach((element) => {
      if (numDividers.includes(element) && gcd % element != 0) {
        gcd *= element;
      }
    });

    this.denominator = Math.floor(this.denominator / gcd);
    this.numerator = Math.floor(this.numerator / gcd);
  },
};

fraction.sum({ numerator: 10, denominator: 8 });
fraction.show();
fraction.difference({ numerator: 5, denominator: 6 });
fraction.show();
fraction.product({ numerator: 9, denominator: 16 });
fraction.show();
fraction.quotient({ numerator: 54, denominator: 32 });
fraction.show();

///

function Fraction(numerator, denominator) {
  this.numerator = numerator;
  this.denominator = denominator;
}

Fraction.prototype.show = function () {
  console.log(`${this.numerator} / ${this.denominator}`);
};

Fraction.prototype.sum = function (fraction2) {
  let res = new Fraction();
  if (this.denominator === fraction2.denominator) {
    res.denominator = this.denominator;
    res.numerator = this.numerator + fraction2.numerator;
  } else {
    res.denominator = this.denominator * fraction2.denominator;
    res.numerator =
      this.numerator * fraction2.denominator +
      fraction2.numerator * this.denominator;
  }

  res.reduction();
  return res;
};

Fraction.prototype.difference = function (fraction2) {
  let res = new Fraction();
  if (this.denominator === fraction2.denominator) {
    res.denominator = this.denominator;
    res.numerator = this.numerator - fraction2.numerator;
  } else {
    res.denominator = this.denominator * fraction2.denominator;
    res.numerator =
      this.numerator * fraction2.denominator -
      fraction2.numerator * this.denominator;
  }

  res.reduction();
  return res;
};

Fraction.prototype.product = function (fraction2) {
  let res = new Fraction();
  res.denominator = this.denominator * fraction2.denominator;
  res.numerator = this.numerator * fraction2.numerator;

  res.reduction();
  return res;
};

Fraction.prototype.quotient = function (fraction2) {
  let res = new Fraction();
  res.denominator = this.denominator * fraction2.numerator;
  res.numerator = this.numerator * fraction2.denominator;

  res.reduction();
  return res;
};

Fraction.prototype.reduction = function () {
  function getDividers(num) {
    let dividers = new Array();
    for (let i = 1; i <= num; i++) {
      if (num % i == 0) {
        dividers.push(i);
      }
    }

    return dividers;
  }

  let denomDividers = getDividers(this.denominator);
  let numDividers = getDividers(this.numerator);
  let gcd = 1;

  denomDividers = denomDividers.reverse();

  denomDividers.forEach((element) => {
    if (numDividers.includes(element) && gcd % element != 0) {
      gcd *= element;
    }
  });

  this.denominator = Math.floor(this.denominator / gcd);
  this.numerator = Math.floor(this.numerator / gcd);
};

let fr = new Fraction(27, 12);
let res = fr.sum(new Fraction(10, 8));
res.show();
res = fr.difference(new Fraction(5, 6));
res.show();
res = fr.product(new Fraction(20, 18));
res.show();
res = fr.quotient(new Fraction(54, 32));
res.show();

///////////////////

// Task 3

var time = {
  hours: 15,
  minutes: 20,
  seconds: 10,
  show: function () {
    let res = "";
    if (this.hours < 10) {
      res += `0`;
    }
    res += `${this.hours} : `;

    if (this.minutes < 10) {
      res += `0`;
    }
    res += `${this.minutes} : `;

    if (this.seconds < 10) {
      res += `0`;
    }
    res += `${this.seconds}`;

    console.log(res);
  },
  check: function () {
    if (this.seconds > 59) {
      this.minutes += Math.floor(this.seconds / 60);
      this.seconds %= 60;
    }
    if (this.minutes > 59) {
      this.hours += Math.floor(this.minutes / 60);
      this.minutes %= 60;
    }
    if (this.hours > 23) {
      this.hours %= 24;
    }
  },
  addSeconds: function (secondsToAdd) {
    this.seconds += secondsToAdd;
    this.check();
  },
  addMinutes: function (minutesToAdd) {
    this.minutes += minutesToAdd;
    this.check();
  },
  addHours: function (hoursToAdd) {
    this.hours += hoursToAdd;
    this.check();
  },
};

time.show();
time.addSeconds(70);
time.show();
time.addMinutes(41);
time.show();
time.addHours(10);
time.show();
