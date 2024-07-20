import React from 'react';
import img from '../../public/hacathon.png';

const Home = () => {
  return (
    <>
      <body>
        <div class="container">
          <div class="row justify-content-center">
            <div class="col-md-8">
              <div class="intro-text text-center">
                <h1 class="mb-4">Welcome to Brand Detection</h1>
                <p class="lead">The innovative application revolutionizing image validation through the power of OpenAI's Vision.</p>
                <p>In a world inundated with visual content, ensuring the authenticity and integrity of images is paramount. Enter Brand Detection: your go-to solution for accurate and reliable image validation. Leveraging the cutting-edge capabilities of OpenAI's Vision, Brand Detection goes beyond traditional methods by analyzing image sets through natural language interactions.</p>
                <p>Here's how it works: we uploaded an image set from wise crawler articles, and our advanced algorithms did the rest. Through seamless integration with OpenAI's Vision, Brand Detection engages in a dialogue, extracting contextual insights, and cross-referencing them with the provided images. This process not only verifies the authenticity of the images but also detects any potential manipulations or discrepancies.</p>
                <p>Whether you're a journalist verifying the authenticity of user-generated content, a researcher conducting image analysis, or a platform combating fake news, Brand Detection empowers you with unparalleled accuracy and efficiency. Say goodbye to manual image validation processes and hello to a streamlined solution powered by AI.</p>
                <p>Ready to experience the future of image validation? Dive into Brand Detection today and witness the seamless integration of AI technology with your image verification needs. Be at the forefront of innovation and ensure the authenticity of your visual content with Brand Detection and OpenAI's Vision.</p>
              </div>
              <div class="d-flex justify-content-center">
                <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTNyOe4xJhJFvDUbm1OSFnnEc4plFTvdYrBmOfNf-YUNA&s" alt="MongoDB Logo" class="rounded-img"/>
                <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/.NET_Core_Logo.svg/1024px-.NET_Core_Logo.svg.png" alt=".NET Logo" class="rounded-img"/>
                <img src="https://www.openai.com/favicon.ico" alt="OpenAI Logo" class="rounded-img"/>
                <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQLP83xYtChQipXCtYEiWTCIgQPw7QOwbVVRxyGgHEF9g&s" alt="React Logo" class="rounded-img"/>
              </div>
              <div class="d-flex justify-content-center">
                <img src={img} alt="Hackathon" class="rounded-img" style={{width: "220px", height: "220px"}}/>
              </div>
            </div>
          </div>
        </div>
      </body>
    </>
  )
}

export default Home
