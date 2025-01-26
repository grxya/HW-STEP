const fs = require("fs/promises");

async function readFile(filepath) {
  try {
    const data = await fs.readFile(filepath, "utf8");
    return data;
  } catch {
    throw new Error("File not found");
  }
}

async function writeFile(filepath, content) {
  try {
    await fs.writeFile(filepath, content + "\n", "utf8");
    return "File updated successfully";
  } catch {
    throw new Error("Error occurred while writing to file");
  }
}

async function appendToFile(filepath, content) {
  try {
    await fs.appendFile(filepath, content + "\n", "utf8");
    return "File updated successfully";
  } catch {
    throw new Error("Error occurred while writing to file");
  }
}

module.exports = { readFile, writeFile, appendToFile };
