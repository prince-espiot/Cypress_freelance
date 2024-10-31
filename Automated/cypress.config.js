const { defineConfig } = require("cypress");

module.exports = {
  reporter: "mochawesome",
  reporterOptions: {
    charts: true,
    reportDir: "cypress/mochawesome-report", // Directory for reports
    reportFilename: "[name]-[datetime]", // Unique filenames
    overwrite: false, // Don't overwrite previous reports
    html: false, // Save JSON for merging
    json: true,
  },
  e2e: {
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
  },
};
