# Use the official Node.js 16 image as a base image
FROM node:16

# Set the working directory inside the container
WORKDIR /app

# Copy the package.json and package-lock.json files to the working directory
COPY package*.json ./

# Install the app dependencies
RUN npm install

# Copy the rest of the application code to the working directory
COPY . .

# Expose the port the app runs on
EXPOSE 8080

# Set the environment variable
ENV NODE_ENV=local

# Command to run the app
CMD ["npm", "start"]