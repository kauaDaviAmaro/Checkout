import http from "./http";

class PurchasesDataService {
    createPurchase(purchase) {
        return http.post("/purchases", purchase).then((response) => {
            return response.data;
        });
    }

    getAllPurchases() {
        return http.get("/purchases").then((response) => {
            return response.data;
        });
    }


    getUserPurchases(id) {
        return http.get(`/Purchases/user/${id}`).then((response) => {
            return response.data;
        });
    }
}

export default new PurchasesDataService();