import http from "./http";

class ProductDataService {
    async getProducts(pageNumber = 0, pageSize = 12, searchQuery = null, category = null, sort = null) {
        const params = {
            pageNumber: pageNumber,
            pageSize: pageSize,
            searchQuery: searchQuery,
            category: category,
            sort: sort
        };

        const data = await http.get('/Product', { params: params }).then((response) => {
            return response.data;
        });

        return data;
    }

    async getProductById(id) {
        const data = await http.get(`/Product/${id}`).then((response) => {
            return response.data;
        });

        return data;
    }

    async deleteProduct(id) {
        await http.delete(`/Product/${id}`);
    }
}

export default new ProductDataService();