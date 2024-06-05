import http from "./http";

class PaymentDataService {
    createPayment(payment) {
        return http.post("/payment", payment).then((response) => {
            return response.data;
        });
    }
}

export default new PaymentDataService();