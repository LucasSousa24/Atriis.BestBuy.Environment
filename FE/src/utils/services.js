import {
    IMAGE_URL
} from "../constants/URIs";

const HTTP_METHOD = {
    GET: "GET",
    POST: "POST",
    PUT: "PUT",
    PATCH: "PATCH",
    DELETE: "DELETE"
};

const defaultHeader = {
    "Content-Type": "application/json; ver=1.0"
};

const generatePayload = (payload) => {
  const {
    filteredBrand,
    pageAt
  } = payload ?? {};
  return {
    filteredBrand: filteredBrand ===  "" ? null : filteredBrand,
    pageAt: pageAt
  };
};

const request = async (path, options) => {
    const { method, body } = options || {};
    const fetchOptions = {
      headers: { ...defaultHeader},
      method: method,
      body: body && JSON.stringify(body),
    };
  
    const res = await fetch(path, fetchOptions);
    const response = res.json();
    if (res.ok) {
      return response;
    }
    const errorResponse = await response;
    throw errorResponse;
};

export const fetchImagesForTable = async (payload) => {
    return await request(
      `${IMAGE_URL}/getfilteredimages`,
      {
        method: HTTP_METHOD.POST,
        body: generatePayload(payload),
      }
    );
};