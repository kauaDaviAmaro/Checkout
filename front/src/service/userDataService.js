import http from "./http";

class UserDataService {
    register(user) {
        return http.post("/register", user);
    }

    login(user) {
        return http.post("/login", user);
    }

    updateUser(user) {
        return http.put("/edit", user);
    }

    logout() {
        return http.post("/logout");
    }

    getCep(cep) {
        return fetch(`https://viacep.com.br/ws/${cep}/json/`)
            .then((res) => res.json());
    }

    getById(id) {
        return http.get(`/user/${id}`).then((response) => {
            return response.data;
        });
    }

    deleteUser(id) {
        return http.delete(`/user/${id}`);
    }

    getUsers(searchName, searchEmail, pageNumber = 0, pageSize = 910) {
        const params = {
            pageNumber: pageNumber,
            pageSize: pageSize,
            searchName: searchName,
            searchEmail: searchEmail
        };
        return http.get("/user", { params: params }).then((response) => {
            return response.data;
        });
    }
}

export default new UserDataService();