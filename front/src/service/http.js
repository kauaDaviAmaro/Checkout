import axios from "axios";

export default axios.create({
    // baseURL: "https://524d-191-242-51-183.ngrok-free.app",
    baseURL: "http://localhost:5094",
    headers: {
        "Content-type": "application/json",
        "ngrok-skip-browser-warning": "true",
    },
})