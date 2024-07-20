# STAGE 1 - build the react app 
# set the base image to build from 
# This is the application image from which all other subsequent 
# applications run. Alpine Linux is a security-oriented, lightweight 
#(~5Mb) Linux distribution.
FROM node:19.6.1-alpine3.17 as build

# set working directory
# this is the working folder in the container from which the app
# will be running from
WORKDIR /app

# copy everything to /app directory
COPY ./build_dev /app/

# STAGE 2 - build the final image using a nginx web server 
# distribution and copy the react build files
FROM nginx:1.24.0-alpine
COPY --from=build /app/ /usr/share/nginx/html

# needed this to make React Router work properly 
RUN rm /etc/nginx/conf.d/default.conf
COPY nginx/nginx.conf /etc/nginx/conf.d

# Expose port 80 for HTTP Traffic 
EXPOSE 80

# start the nginx web server
CMD ["nginx", "-g", "daemon off;"]