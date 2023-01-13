var lib = {},
    API_URL = "https://localhost:7134"

    lib.URL = function (service) {
    return API_URL + service
}

module.exports = lib