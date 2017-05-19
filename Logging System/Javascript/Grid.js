
        $(function () {

            $("#grid").jqGrid({
                url: "/Registered/SelectLearners",
                datatype: 'json',
                mtype: 'Get',
                colNames: ["LearnerID", "Names", "Surname","Gender", "DOB", "RSAID", "Learnership", "Mobile","Email", "Username", "Password", "IsUserActive"],
                colModel: [{ name: "LearnerID", key: true, index: 'LearnerID', hidden: true, editable: true },
                    { name: "Names", index: 'Names', editable: true, sortable: true },
                    { name: "Surname", index: 'Surname', editable: true, sortable: true },
                    { name: "Gender", index: 'Gender', align: 'center', editable: true, sortable: true },
                    { name: "DOB", index: 'DOB', formatter: "date", formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' }, editable: true },
                    { name: "RSAID", index: 'RSAID', align: 'right', editable: true },
                    { name: "Learnership", index: 'Learnership', align: 'right', editable: true },
                    { name: "Mobile", index: 'Mobile', align: 'right', editable: true },
                    { name: "Email", index: 'Email', align: 'right', editable: true },
                    { name: "Username", index: 'Username', align: 'right', editable: true },
                    { name: "Password", index: 'Password', align: 'right', editable: true },
                    { name: "IsUserActive", index: 'IsActive', align: 'right', editable: true },

                ],


                height: 'auto',
                autowidth: 'true',
                rowNum: 20,
                loadonce: true,
                rowList: [10, 20, 30],
                pager: 'pager',
                sortname: 'Names',
                viewrecords: true,
                sortorder: 'asc',
                caption: 'Registered Learners', align: 'center',
                emptyrecords: 'No Records To Display',
                jsonreader: {
                    repeatitems: false,
                    Id: "0"
                },
                multiselect: false,

            }).navGrid('#pager', { edit: true, add: true, del: true, search: true, refresh: true, },

            {
                //EDIT OPTIONS
                width: 600,
                url: '/Registered/UpdateLearner',
                closeAfterEdit: true,
                onInitializeForm: function () {
                    $('#DOB').datepicker({
                        changeMonth: true,
                        changeYear: true,
                        nextText: "",
                        prevText: ""
                    })
                },
                afterComplete: function (response) {
                    $('#grid').setGridParam({ datatype: 'json', page: 1 }).trigger('reloadGrid');
                    alert(response.responseText)
                },

            },
        {
            //ADD OPTIONS
            width: 600,
            url: '/Registered/InsertLearner',
            closeAfterAdd: true,
            onInitializeForm: function () {
                $('#DOB').datepicker({
                    changeMonth: true,
                    changeYear: true,
                    nextText: "",
                    prevText: ""
                })
            },
            afterComplete: function (response) {
                $('#grid').setGridParam({ datatype: 'json', page: 1 }).trigger('reloadGrid');
                alert(response.responseText)
            },

        },
        {
            //DELETE OPTIONS
            width: 600,
            url: '/Registered/DeleteLearner',
            closeAfterDelete: true,
            msg: "Are you sure you want to permanently delete this record?",
            afterComplete: function (response) {
                $('#grid').setGridParam({ datatype: 'json', page: 1 }).trigger('reloadGrid');
                alert(response.responseText)
            },

        },
        {
            //SEARCH OPTIONS
            width: 600,
            multipleSearch: true,

        }

        );
        });
