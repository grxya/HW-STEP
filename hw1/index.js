const http = require("http");
const { readFile, writeFile, appendToFile } = require("./fileManager");

const server = http.createServer(async (req, res) => {
  if (req.url == "/") {
    res.end("Welcome to my first Node.js server!");
  } else if (req.url == "/file" && req.method == "GET") {
    try {
      const data = await readFile("data.txt");
      res.end(data);
    } catch {
      res.end("File not found");
    }
  } else if (req.url == "/file" && req.method == "POST") {
    let content = "";
    req.on("data", (text) => (content += text));
    req.on("end", async () => {
      try {
        await writeFile("data.txt", content);
        res.end("File successfully updated");
      } catch {
        res.end("Error occurred while writing to file");
      }
    });
  } else if (req.url == "/file/append" && req.method == "POST") {
    let content = "";
    req.on("data", (text) => (content += text));
    req.on("end", async () => {
      try {
        await appendToFile("data.txt", content);
        res.end("File successfully updated");
      } catch {
        res.end("Error occurred while writing to file");
      }
    });
  } else if (req.url == "/time") {
    res.end(`Current time: ${new Date().toLocaleTimeString()}`);
  } else if (req.url == "/date") {
    res.end(`Current date: ${new Date().toISOString().split("T")[0]}`);
  } else {
    res.end("404: Page not found");
  }
});

server.listen(3000, () => {
  console.log("Server is running on port 3000");
});
