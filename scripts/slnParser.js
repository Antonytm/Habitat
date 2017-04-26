"use strict";
var xml2js = require("xml2js");
var fs = require("fs");
var reg = new RegExp(/Project\("{.+}"\) = "(.+)", "(.+\.csproj)"/gi);

var slnParser = {};

slnParser.getGroup = function getGroup(filename, index) {
  var projects = [];
  var targetText = fs.readFileSync(filename, "utf8");
  var i = 0;
  var result;
  while ((result = reg.exec(targetText)) !== null) {
    projects[i] = result[index];
    i = i + 1;
  }
  return projects;
};

slnParser.getProjectNames = function getProjectNames(filename) {
  return slnParser.getGroup(filename, 1);
};

slnParser.getProjectPaths = function getProjectPaths(filename) {
  return slnParser.getGroup(filename, 2);
};

module.exports = slnParser;