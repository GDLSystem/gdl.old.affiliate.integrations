$(function () {
    var l = abp.localization.getResource("Integrations");
	var shopinessClickService = window.gdl.affiliate.integrations.controllers.shopinessClicks.shopinessClick;
	
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "ShopinessClicks/CreateModal",
        scriptUrl: "/Pages/ShopinessClicks/createModal.js",
        modalClass: "shopinessClickCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "ShopinessClicks/EditModal",
        scriptUrl: "/Pages/ShopinessClicks/editModal.js",
        modalClass: "shopinessClickEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            clickMin: $("#ClickFilterMin").val(),
			clickMax: $("#ClickFilterMax").val(),
			affiliateOwnershipType: $("#AffiliateOwnershipTypeFilter").val(),
			createdAtMin: $("#CreatedAtFilterMin").data().datepicker.getFormattedDate('yyyy-mm-dd'),
			createdAtMax: $("#CreatedAtFilterMax").data().datepicker.getFormattedDate('yyyy-mm-dd')
        };
    };

    var dataTable = $("#ShopinessClicksTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(shopinessClickService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Integrations.ShopinessClicks.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Integrations.ShopinessClicks.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    shopinessClickService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "click" },
            {
                data: "affiliateOwnershipType",
                render: function (affiliateOwnershipType) {
                    if (affiliateOwnershipType === undefined ||
                        affiliateOwnershipType === null) {
                        return "";
                    }

                    var localizationKey = "Enum:AffiliateOwnershipType:" + affiliateOwnershipType;
                    var localized = l(localizationKey);

                    if (localized === localizationKey) {
                        abp.log.warn("No localization found for " + localizationKey);
                        return "";
                    }

                    return localized;
                }
            },
            {
                data: "createdAt",
                render: function (createdAt) {
                    if (!createdAt) {
                        return "";
                    }
                    
					var date = Date.parse(createdAt);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
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

    $("#NewShopinessClickButton").click(function (e) {
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
