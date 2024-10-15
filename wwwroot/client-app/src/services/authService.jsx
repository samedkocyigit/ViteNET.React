/* eslint-disable no-useless-catch */
export const login = async (credential) => {
  try {
    const response = await fetch("http://localhost:5198/api/auth/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(credential),
    });

    if (!response.ok) {
      throw new Error("Login failed");
    }

    return await response.json();
  } catch (err) {
    throw err;
  }
};

export const register = async (userData) => {
  const response = await fetch("http://localhost:5198/api/auth/register", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userData),
  });
  return response.json();
};

export const logout = async () => {
  const response = await fetch("http://localhost:5198/api/auth/logout");
  console.log("response", response.json());
  return response.json();
};
