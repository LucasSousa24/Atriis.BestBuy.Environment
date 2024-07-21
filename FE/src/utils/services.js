import {
  PRODUCT_URL,
  USER_URL
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
    pageAt,
    nameFilter,
    productCategoryFilter
  } = payload ?? {};
  return {
    pageAt: Number(pageAt),
    nameFilter: nameFilter,
    productCategoryFilter: productCategoryFilter
  };
};

const generateUserPayload = (payload) => {
  const {
    nameFilter,
    productCategoryFilter
  } = payload ?? {};
  return {
    id: 1,
    username: "user1",
    password: "password1",
    isDeleted: false,
    createdOn: new Date(),
    updatedOn: new Date(),
    nameFilter: nameFilter,
    productCategoryFilter: productCategoryFilter
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

export const fetchProductsForTable = async (payload) => {
    return await request(
      `${PRODUCT_URL}/getallfilteredproducts`,
      {
        method: HTTP_METHOD.POST,
        body: generatePayload(payload),
      }
    );
};

export const updateFiltersForUser = async (payload) => {
  return await request(
    `${USER_URL}`,
    {
      method: HTTP_METHOD.PUT,
      body: generateUserPayload(payload),
    }
  );
};

export const fetchUserByCredentials = async () => {
  return await request(`${USER_URL}?username=user1&password=password1`, {
    method: HTTP_METHOD.GET
  });
};