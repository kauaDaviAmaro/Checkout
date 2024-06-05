import http from "./http";

class ContactDataService {
    createPurchase(purchase) {
        return http.post("/purchases", purchase).then((response) => {
            return response.data;
        });
    }
}

export default new ContactDataService();