$(function () {
    var l = abp.localization.getResource("Integrations");
	var shopinessConversionService = window.gdl.affiliate.integrations.controllers.shopinessConversions.shopinessConversion;
	
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "ShopinessConversions/CreateModal",
        scriptUrl: "/Pages/ShopinessConversions/createModal.js",
        modalClass: "shopinessConversionCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "ShopinessConversions/EditModal",
        scriptUrl: "/Pages/ShopinessConversions/editModal.js",
        modalClass: "shopinessConversionEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            conversionItemId: $("#ConversionItemIdFilter").val(),
			conversionId: $("#ConversionIdFilter").val(),
			status: $("#StatusFilter").val(),
			saleAmountMin: $("#SaleAmountFilterMin").val(),
			saleAmountMax: $("#SaleAmountFilterMax").val(),
			payoutMin: $("#PayoutFilterMin").val(),
			payoutMax: $("#PayoutFilterMax").val(),
			payoutBonusMin: $("#PayoutBonusFilterMin").val(),
			payoutBonusMax: $("#PayoutBonusFilterMax").val(),
			conversionTimeMin: $("#ConversionTimeFilterMin").val(),
			conversionTimeMax: $("#ConversionTimeFilterMax").val(),
			platform: $("#PlatformFilter").val(),
			subId1: $("#SubId1Filter").val(),
			subId2: $("#SubId2Filter").val(),
			subId3: $("#SubId3Filter").val(),
			shopId: $("#ShopIdFilter").val(),
			shortKey: $("#ShortKeyFilter").val(),
			shopName: $("#ShopNameFilter").val(),
			productName: $("#ProductNameFilter").val(),
			categoryName: $("#CategoryNameFilter").val(),
			campaign: $("#CampaignFilter").val(),
            isHappyDay: (function () {
                var value = $("#IsHappyDayFilter").val();
                if (value === undefined || value === null || value === '') {
                    return '';
                }
                return value === 'true';
            })()
        };
    };

    var dataTable = $("#ShopinessConversionsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(shopinessConversionService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Integrations.ShopinessConversions.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Integrations.ShopinessConversions.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    shopinessConversionService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "conversionItemId" },
			{ data: "conversionId" },
			{ data: "status" },
			{ data: "saleAmount" },
			{ data: "payout" },
			{ data: "payoutBonus" },
			{ data: "conversionTime" },
			{ data: "platform" },
			{ data: "subId1" },
			{ data: "subId2" },
			{ data: "subId3" },
			{ data: "shopId" },
			{ data: "shortKey" },
			{ data: "shopName" },
			{ data: "productName" },
			{ data: "categoryName" },
			{ data: "campaign" },
            {
                data: "isHappyDay",
                render: function (isHappyDay) {
                    return isHappyDay ? l("Yes") : l("No");
                }
            }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewShopinessConversionButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });

    $('#AdvancedFilterSectionToggler').on('click', function (e) {
        $('#AdvancedFilterSection').toggle();
    });

    $('#AdvancedFilterSection').on('keypress', function (e) {
        if (e.which === 13) {
            dataTable.ajax.reload();
        }
    });

    $('#AdvancedFilterSection select').change(function() {
        dataTable.ajax.reload();
    });
});
