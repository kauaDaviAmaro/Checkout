const url = "http://localhost:5094";

export const login = async (formData) => {
    const email = formData.email;
    const password = formData.password;

    try {
        const response = await fetch(`${url}/login?useCookies=true`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({ email, password }),
        });

        if (!response.ok) {
            const error = await response.json();
            throw error;
        }

        return response.status;

    } catch (err) {
        return err;
    }
}

export const register = async (formData) => {
    const email = formData.email;
    const password = formData.password;

    try {
        const response = await fetch(`${url}/register`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({ email, password }),
        });

        if (!response.ok) {
            const error = await response.json();
            throw error;
        }

        return response.status;
    } catch (err) {
        return err;
    }
}

