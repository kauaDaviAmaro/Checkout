import http from "./http";

class addressDataService {
    createAddress(address) {
        return http.post("/address", address).then((response) => {
            return response.data;
        });
    }
}

export default new addressDataService();