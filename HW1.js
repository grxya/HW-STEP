//1
function isBiggger(num1, num2) {
  if (num1 > num2) {
    return 1;
  } else if (num1 < num2) {
    return -1;
  } else {
    return 0;
  }
}

//2
function factorial(num) {
  let result = 1;
  for (i = 2; i <= num; i++) {
    result *= i;
  }
  return result;
}

//3
function newNum(num1, num2, num3) {
  return num1 * 100 + num2 * 10 + num3;
}

//4
function area(num1, num2) {
  let a;
  if (num2 != null) {
    return num1 * num2;
  } else {
    return num1 * num1;
  }
}

//5
function isPerfect(num) {
  let a = 0;
  for (i = 1; i < num; i++) {
    if (num % i == 0) {
      a += i;
    }
  }

  if (num == a) {
    return true;
  } else {
    return false;
  }
}

//6
function perfectNums(num1, num2) {
  let a = "";
  for (i = num1; i <= num2; i++) {
    if (isPerfect(i)) {
      a += `${i} `;
    }
  }
  return a;
}

//7
function formatTime(hours, minutes, seconds) {
  function check(num) {
    if (num == null) {
      num = "00";
    } else if (num < 10) {
      num = "0" + num;
    }
    return num;
  }

  hours = check(hours);
  minutes = check(minutes);
  seconds = check(seconds);

  return hours + ":" + minutes + ":" + seconds;
}

//8
function toSeconds(hours, minutes, seconds) {
  return hours * 60 * 60 + minutes * 60 + seconds;
}

//9
function secondsToTime(seconds) {
  let a = Math.floor(seconds / 60);
  seconds = seconds % 60;
  let minutes = a % 60;
  let hours = Math.floor(a / 60);

  return hours + ":" + minutes + ":" + seconds;
}

//10
function timeGap(hours1, minutes1, seconds1, hours2, minutes2, seconds2) {
  let first = toSeconds(hours1, minutes1, seconds1);
  let second = toSeconds(hours2, minutes2, seconds2);

  return secondsToTime(first - second);
}

console.log("Task 1: " + isBiggger(5, 6));
console.log("Task 2: " + factorial(5));
console.log("Task 3: " + newNum(2, 4, 5));
console.log("Task 4: " + area(5));
console.log("Task 5: " + isPerfect(6));
console.log("Task 6: " + perfectNums(5, 37));
console.log("Task 7: " + formatTime(5, 6));
console.log("Task 8: " + toSeconds(4, 6, 30));
console.log("Task 9: " + secondsToTime(19820));
console.log("Task 10: " + timeGap(5, 26, 25, 4, 6, 30));
